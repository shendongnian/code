    @if (post.Comments != null) //added this
                {
                foreach (Comment comment in post.Comments.OrderBy(x => x.CommentCreateDate))
                {
    
                <div class="comment">
                    <div class="commentName">
                        @if (!string.IsNullOrWhiteSpace(comment.EmailAddress))
                        {
                            <a href="mailto: @comment.EmailAddress;">@comment.CommeterName</a>
                        }
                        else
                        {
                            @comment.CommeterName;
                        }
                    </div>
                    said:
                    <div class="commentBody">@Html.Raw(Html.Encode(comment.CommentText).Replace("\n", "<br/>"))</div>
                    <div class="commentTime">at @comment.CommentCreateDate.ToString() on @comment.CommentCreateDate.ToString()</div>
                </div>
                }
           }
