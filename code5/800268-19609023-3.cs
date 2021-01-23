    public static class RenderEngine
    {
        private static readonly IGenericService<Component> ComponentService;
        private static readonly IGenericService<TextBlock> TextBlockService;
    
        /// <summary>
        /// Constructor for this class.
        /// </summary>
        static RenderEngine()
        {
            if (ComponentService == null)
            {
                ComponentService = new GenericService<Component>();
            }
            if (TextBlockService == null)
            {
                TextBlockService = new GenericService<TextBlock>();
            }
        }
    
        //Html helper method does something like TekstBlokService.First(/*linq statement*/)
    }
