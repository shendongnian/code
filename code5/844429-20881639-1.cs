    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual JsonResult Create(CommentViewModel commentViewModel)
    {
        CommentDto comentDto = Mapper.Map<CommentViewModel, CommentDto>(commentViewModel);
        _commentService.Create(comentDto);
        commentViewModel.Result = HeelpResources.CommentViewModelResultMsgOk;
        return Json(commentViewModel);
    }
