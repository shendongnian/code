    var query = from comment in SH_Comments
			join user in Users
			on comment.UserID equals user.UserID
			
			join product in SH_Products
			on comment.ProductID equals product.ID
			
			join vote in SH_CommentVotes
			on comment.ID equals vote.CommentID
			
			group comment by new
			{
				comment.Body,
				comment.CreatedDate,
				comment.IsApproved,
				comment.IsRead,
				comment.ID,
				comment.ProductID,
				comment.UserID,
				comment.ParentID,
				user.DisplayName,
				user.Username,
				product.Title,
				vote.IsPositive
			} into g
			
			select new
			{
				g.Key.Body,
				g.Key.CreatedDate,
				g.Key.IsApproved,
				g.Key.IsRead,
				g.Key.ID,
				g.Key.ProductID,
				g.Key.UserID,
				g.Key.ParentID,
				g.Key.DisplayName,
				g.Key.Username,
				g.Key.Title,
				PositiveVotes = g.Where(c=>g.Key.IsPositive).Count(),
				NegativeVotes = g.Where(c=>!g.Key.IsPositive).Count()
			};		
			
    var list = query
			.GroupBy(x => new
			{ 
				x.Title,
				x.Body,
				x.CreatedDate,
				x.IsApproved,
				x.IsRead,
				x.ID,
				x.ProductID,
				x.UserID,
				x.ParentID,
				x.DisplayName,
				x.Username,
				
			})
			.Select(x => new 
			{ 
				x.Key.Body,
				x.Key.CreatedDate,
				x.Key.IsApproved,
				x.Key.IsRead,
				x.Key.ID,
				x.Key.ProductID,
				x.Key.UserID,
				x.Key.ParentID,
				x.Key.DisplayName,
				x.Key.Username,
				x.Key.Title,
				PositiveVotes = x.Sum(s => s.PositiveVotes),
				NegativeVotes = x.Sum(s => s.NegativeVotes) 
			});
