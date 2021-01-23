    List<CommentList> query = from c in db.Comments
                    join s in db.Status on c.StatusId equals s.StatusId
                    join d in db.DiscussionBoards on c.DiscussionBoardId equals d.DiscussionBoardId
                    where d.CourseId == "CourseID"
                    orderby d.ItemType, d.DiscussionBoardId
                    select new CommentList
                    {
                        ItemType = d.ItemType,
                        Comment1 = c.Comment1,
                        Status1= s.Status1,
                        DiscussionBoardId = c.DiscussionBoardId,
                        CourseId = d.CourseId,
                        CommentId = c.CommentID
                    };
