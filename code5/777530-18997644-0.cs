     public AddCouponCodesViewModel(): 
        this(new UmbracoHelper(UmbracoContext.Current).
    TypedContent(UmbracoContext.Current.PageId))
       {
       }
