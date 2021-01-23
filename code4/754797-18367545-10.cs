    builder.Register<Func<IHtml, IElement>>(dom =>
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
    });
      
    public class NeedsAnElementFactory //also registered in AutoFac
    {
        protected Func<IHtml,IElement> CreateElement {get; private set;}
                 
        //AutoFac will constructor-inject the Func you registered
        //whenever this class is resolved.
        public NeedsAnElementFactory(Func<IHtml,IElement> elementFactory)
        {
            CreateElement = elementFactory;
        }  
        public void MethodUsingElementFactory()
        {
            IHtml domInstance = GetTheDOM();
            var element = CreateElement(domInstance);
            //the next line won't compile;
            //the factory method is strongly typed to IHtml
            var element2 = CreateElement("foo");
        }
    }
