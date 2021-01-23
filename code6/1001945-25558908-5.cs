    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace TestRequestResponse
    {
    
        #region Generic portions
    
        /// <summary>
        /// Base request class
        /// </summary>
        public  class       Request {}
    
        /// <summary>
        /// Base response class
        /// </summary>
        public  class       Response {}
    
        /// <summary>
        /// Generic typed namespace for Response/Request support
        /// </summary>
        /// <typeparam name="tRequestResponseSet">Request/Response set type parameter (for namespace constraining)</typeparam>
        /// <typeparam name="tItem">Item type parameter</typeparam>
        /// <typeparam name="tSourceItem">Source item type parameter</typeparam>
        public  class       RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>
                where       tRequestResponseSet : RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>
                where       tItem               : RequestResponseSet<tRequestResponseSet, tItem, tSourceItem>.Item
        {
    
            /// <summary>
            /// Base item class
            /// </summary>
            public
            abstract    class   Item
            {
                public
                abstract    void    Initialize(tSourceItem sourceItem);
            }
    
            /// <summary>
            /// Base type specific subclassable enum class (see https://github.com/TyreeJackson/atomic/blob/master/Atomic.Net/DataTypes/SubclassableEnum.cs for a more generic version)
            /// </summary>
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
    
        #endregion Generic portions
    
        #region Post specific portions
    
        /// <summary>
        /// Stored post /entity
        /// </summary>
        public  class       StoredPost
        {
            public  String          Type    { get; set; }
            public  Int32           Id      { get; set; }
            public  String          Title   { get; set; }
            public  String          Text    { get; set; }
            public  List<String>    Tags    { get; set; }
        }
    
        /// <summary>
        /// Post specific typed namespace
        /// </summary>
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
    
        /// <summary>
        /// Post specific response class
        /// </summary>
        public  class       FindPostsResponse : Response
        {
            public IList<PostsSet.Post> Posts   { get; set; }
        }
    
        /// <summary>
        /// Post specific request class
        /// </summary>
        public  class       FindPostsRequest : Request
        {
            public  string  Type    { get; set; }
        }
    
        /// <summary>
        /// Post specific context
        /// </summary>
        public  interface   IContext
        {
            IEnumerable<StoredPost> Posts   { get; set; }
        }
    
        /// <summary>
        /// Post specific handler
        /// </summary>
        public  class       FindPostHandler
        {
    
            private IContext            context;
    
            public                      FindPostHandler(IContext context)
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
    
        #endregion Post specific portions
    
    }
