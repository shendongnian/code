    public static class InputExtensions
    // ^^ this is where Extension Methods must be placed (inside of a static class)
    {
        public static MvcHtmlString TextBoxFor<TModel, TProperty>
        //     ^^ they must also be static    ^^ here must be defined all the generic types
        //                                       which are involved withing the method
            (this HtmlHelper<TModel> htmlHelper, 
        //   ^^ the first parameter must have "this"
        //      this is a parameter which defines the type that the method operates on
        //      so, in this case, it must be some "HtmlHelper<TModel>" class instance
             Expression<Func<TModel, TProperty>> expression)
        //   ^^ the second parameter in the declaration, 
        //      but the first one which appears from caller side (the only one in this very case)
        {
            string format = (string) null;
            return InputExtensions.TextBoxFor<TModel, TProperty>
                   (htmlHelper, expression, format);
            // or might also be (dependently if the types 
            //    can be resolved automatically by compiller (the explanation below))
            //    as follows:
            return InputExtensions.TextBoxFor
                   (htmlHelper, expression, format);
        }
    }
