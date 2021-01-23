    protected override void Execute(NativeActivityContext context)
    {
         NoPersistHandle handle = noPersistHandle.Get(context);
         handle.Enter(context);
         context.CreateBookmark(bookmarkString, this.Continue, bookmarkOptions);
    }
    
    private void Continue(NativeActivityContext context, Bookmark bookmark, Object obj)
    {
          NoPersistHandle handle = noPersistHandle.Get(context);
          handle.Exit(context);
    }
