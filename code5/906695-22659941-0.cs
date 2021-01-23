    enum AError
    {
        AError1,
        AError2,
        AError3,
        AError4,
        AError5,
    }
    delegate bool SingleErrorHandlerDelegate<T>(T error, object someOtherPayload);
    interface IHandle<T>
    {
        bool Handle(T error, object someOtherPayload); // return true if handled;
    }
    class ErrorHandlerFor<T> : IHandle<T>
    {
        private Dictionary<T, SingleErrorHandlerDelegate<T>> handlers;
        private static T[] enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        public ErrorHandlerFor(IEnumerable<KeyValuePair<IEnumerable<T>, SingleErrorHandlerDelegate<T>>> handlers)
            : this(handlers.SelectMany(h => h.Key.Select(key => new KeyValuePair<T, SingleErrorHandlerDelegate<T>>(key, h.Value))))
        {
        }
        public ErrorHandlerFor(IEnumerable<KeyValuePair<IEnumerable<T>, SingleErrorHandlerDelegate<T>>> handlers, SingleErrorHandlerDelegate<T> fallbackHandler)
            : this(handlers.SelectMany(h => h.Key.Select(key => new KeyValuePair<T, SingleErrorHandlerDelegate<T>>(key, h.Value))), fallbackHandler)
        {
        }
        public ErrorHandlerFor(IEnumerable<KeyValuePair<T, SingleErrorHandlerDelegate<T>>> handlers)
        {
            this.handlers = new Dictionary<T, SingleErrorHandlerDelegate<T>>();
            foreach (var handler in handlers)
            {
                Debug.Assert(handler.Value != null);
                this.handlers.Add(handler.Key, handler.Value);
            }
            checkHandlers();
        }
        public ErrorHandlerFor(IEnumerable<KeyValuePair<T, SingleErrorHandlerDelegate<T>>> handlers, SingleErrorHandlerDelegate<T> fallbackHandler)
        {
            this.handlers = new Dictionary<T, SingleErrorHandlerDelegate<T>>();
            foreach (var handler in handlers)
            {
                Debug.Assert(handler.Value != null);
                this.handlers.Add(handler.Key, handler.Value);
            }
            foreach (var enumValue in enumValues)
            {
                if (this.handlers.ContainsKey(enumValue) == false)
                {
                    this.handlers.Add(enumValue, fallbackHandler);
                }
            }
            checkHandlers();
        }
        private void checkHandlers()
        {
            foreach (var enumValue in enumValues)
            {
                Debug.Assert(handlers.ContainsKey(enumValue));
            }
        }
        public bool Handle(T error, object someOtherPayload)
        {
            return handlers[error](error: error, someOtherPayload: someOtherPayload);
        }
    }
    class Test
    {
        public static void test()
        {
            var handler = new ErrorHandlerFor<AError>(
                new[]{
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError1, AError.AError2, AError.AError4,},
                    (AError error, object payload) => { Console.WriteLine(@"handled error 1, 2 or 4!"); return true;}
                    ),
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError3, AError.AError5,},
                    (AError error, object payload) => { Console.WriteLine(@"could not handle error 3 or 5!"); return false;}
                    ),
                }
                );
            var result = Services.foo(handler);
            var incompleteHandlerButWithFallbackThatWillPassTheTest = new ErrorHandlerFor<AError>(
                new[]{
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError1, AError.AError2, AError.AError4,},
                    (AError error, object payload) => { Console.WriteLine(@"handled error 1, 2 or 4!"); return true;}
                    ),
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError5},
                    (AError error, object payload) => { Console.WriteLine(@"could not handle error 3 or 5!"); return false;}
                    ),
                }
                // AError.AError3 is not handled!  => will go in fallback
                , (AError error, object payload) => { Console.WriteLine(@"could not handle error in fallback!"); return false; }
                );
            var result2 = Services.foo(incompleteHandlerButWithFallbackThatWillPassTheTest);
            var incompleteHandlerThatWillBeDetectedUponInstantiation = new ErrorHandlerFor<AError>(
                new[]{
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError1, AError.AError2, AError.AError4,},
                    (AError error, object payload) => { Console.WriteLine(@"handled error 1, 2 or 4!"); return true;}
                    ),
                    new KeyValuePair<IEnumerable<AError>, SingleErrorHandlerDelegate<AError>>(
                    new []{AError.AError3},
                    (AError error, object payload) => { Console.WriteLine(@"could not handle error 3 or 5!"); return false;}
                    ),
                } // AError.AError5 is not handled!  => will trigger the assertion!
                );
        }
    }
    class Services
    {
        public static Result foo(IHandle<AError> errorHandler)
        {
            Debug.Assert(errorHandler != null);
            // raise error...
            var myError = AError.AError1;
            var handled = errorHandler.Handle(error: myError, someOtherPayload: "hello");
            if (!handled)
                return new Result();
            // maybe proceed
            var myOtherError = AError.AError3;
            errorHandler.Handle(error: myOtherError, someOtherPayload: 42); //we'll return anyway in this case...
            return new Result();
        }
        public class Result
        {
        }
    }
