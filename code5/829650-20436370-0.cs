	var articles =
		(from a in context.Module_Articles_Articles
		 join c in context.Module_Articles_Categories on a.CategoryID equals c.CategoryID into joinTable1
		 from c in joinTable1.DefaultIfEmpty()
		 join co in context.Module_Articles_Comments on a.ArticleID equals co.ArticleID into joinTable2
		 from co in joinTable2.DefaultIfEmpty()
		 where a.IsDraft == false
		 orderby a.ArticleID descending
		 select new
		 {
			 a.ArticleID,
			 a.ArticleTitle,
			 a.ArticleContent,
			 a.Image,
			 a.Sender,
			 a.SentDate,
			 a.Summary,
			 a.Likes,
			 a.Dislikes,
			 a.Tags,
			 a.PostMode,
			 c.CategoryID,
			 c.CategoryTitle,
			 AcceptedCommentsCount = 
			 (from com in context.Module_Articles_Comments where com.ArticleID == a.ArticleID && com.Status select com)
			 .Count(),
			 DeniedCommentsCount =
			 (from com in context.Module_Articles_Comments where com.ArticleID == a.ArticleID 
				  && com.Status == false select com)
			 .Count()
		 }).ToList();
