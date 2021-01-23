            cb.Register(ctx =>
            {
                var other = ctx.Resolve<SomeOtherType>();
                var obj = new SomeType();
                obj.Input += other.Output;
                return obj;
            }).As<SomeType>();
