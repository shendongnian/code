    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = new Castle.Windsor.WindsorContainer();
                container.Register
                (
                    Component
                    .For<Restricted>()
                    .UsingFactoryMethod
                    (
                        (k, c) =>
                        {
                            var requestingType = c.Handler.ComponentModel.Implementation;
                            if (requestingType == typeof(Allowed))
                            {
                                return new RestrictedImp();
                            }
                            else
                            {
                                var errorMessage = string.Format
                                (
                                    "The type [{0}] is not permitted to resolve [{1}].", 
                                    requestingType.Name, 
                                    c.RequestedType.Name
                                );
                                throw new InvalidOperationException(errorMessage);
                            }
                        }
                    )
                    .LifeStyle
                    .Transient
                );
                container.Register(Component.For<Allowed>());
                container.Register(Component.For<Disallowed>());
                var a = container.Resolve<Allowed>();
                var b = container.Resolve<Disallowed>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
    interface Restricted { }
    class RestrictedImp : Restricted
    {
    }
    class Allowed
    {
        public Allowed(Restricted restricted)
        {
        }
    }
    class Disallowed
    {
        public Disallowed(Restricted restricted)
        {
        }
    }
