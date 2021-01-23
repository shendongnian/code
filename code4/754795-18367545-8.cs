    public class ElementFactory
    {
        public static IElement Create(IHtml dom)
        {
            switch (dom.ElementType)
            {
                case "table":
                    return new TableElement(dom);
                case "div":
                    return new DivElement(dom);
                case "span":
                    return new SpanElement(dom);
            }
            return new PassthroughElement(dom);
        }
    }
    
    ...
    
    builder.Register<Func<IHtml, IElement>>(ElementFactory.Create);
