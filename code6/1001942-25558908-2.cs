    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestRequestResponse
    {
    
        public  class       Request {}
        public  class       Response {}
    
        public  class       RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>
                where       tRequestResponseSet : RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>
                where       tItem               : RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>.Item
        {
    
            public
            abstract    class   Item
            {
                public
                abstract    void    Initialize(tSourceItem sourceItem);
            }
        
            public
            abstract    class   ResponseTypeEnum
            {
                private
                static      Dictionary
                            <
                                string,
                                ResponseTypeEnum
                            >                       allValues                       = new Dictionary<string,ResponseTypeEnum>();
                private     string                  type;
                private     Func<tItem>             constructItem;
                protected                           ResponseTypeEnum
                                                    (
                                                        string      type, 
                                                        Func<tItem> constructItem
                                                    )
                {
                    this.type           = type;
                    this.constructItem  = constructItem;
                }
    
                public      tItem                   ConstructItem(tSourceItem sourceItem)
                {
                    var returnItem  = this.constructItem();
                    returnItem.Initialize(sourceItem);
                    return returnItem;
                }
    
                public
                static      ResponseTypeEnum        Select(string type)
                {
                    ResponseTypeEnum returnTypeEnum = null;
                    return  type == null || !ResponseTypeEnum.allValues.TryGetValue(type, out returnTypeEnum)
                            ?   null
                            :   returnTypeEnum;
                }
    
                public
                static
                implicit
                operator                            ResponseTypeEnum(string type)
                {
                    return ResponseTypeEnum.Select(type);
                }
    
                public
                static
                implicit
                operator                            string(ResponseTypeEnum typeEnum)
                {
                    return typeEnum == null ? null : typeEnum.type;
                }
                
            }
    
        }
    
        public  class       StoredPost
        {
            public  String          Type    { get; set; }
            public  Int32           Id      { get; set; }
            public  String          Title   { get; set; }
            public  String          Text    { get; set; }
            public  List<String>    Tags    { get; set; }
        }
    
        public  class       PostsSet : RequestResponseSet<PostsSet, PostsSet.Post, StoredPost>
        {
    
            public  class   Types : ResponseTypeEnum
            {
    
                public  static      Types   Basic       = new Types("basic",    ()=>new Post());
                public  static      Types   WithTags    = new Types("withTags", ()=>new PostWithTags());
    
                protected                   Types(string type, Func<Post> createPost) : base(type, createPost) {}
            }
    
            public  class   Post : Item
            {
                public      Int32   Id      { get; set; }
                public      String  Title   { get; set; }
                public      String  Text    { get; set; }
    
                public
                override    void    Initialize(StoredPost sourceItem)
                {
                    this.Id     = sourceItem.Id;
                    this.Title  = sourceItem.Title;
                    this.Text   = sourceItem.Text;
                }
    
            }
    
            public  class   PostWithTags : Post
            {
                public      List<String>    Tags    { get; set; }
    
                public
                override    void            Initialize(StoredPost sourceItem)
                {
                    base.Initialize(sourceItem);
                    this.Tags   = sourceItem.Tags;
                }
            }
    
        }
    
        public  class       FindPostsResponse : Response
        {
            public IList<PostsSet.Post> Posts   { get; set; }
        }
    
        public  class       FindPostsRequest : Request
        {
            public  string  Type    { get; set; }
        }
    
        public  interface   IContext
        {
            IEnumerable<StoredPost> Posts   { get; set; }
        }
    
        public  class       FindPostHandler
        {
    
            private IContext    context;
    
            public              FindPostHandler(IContext context)
            {
                this.context    = context;
            }
    
            public  FindPostsResponse   Handle(FindPostsRequest request)
            {
                var type    = PostsSet.Types.Select(request.Type);
    
                return
                type == null
                ?   null
                :   new FindPostsResponse()
                    {
                        Posts   =
                        this.context.Posts
                        .Where(x => x.Type == request.Type)
                        .Select(x => type.ConstructItem(x))
                        .ToList()
                    };
            }
    
        }
    
    }
