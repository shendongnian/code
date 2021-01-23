      from tt in ( from s in Folder.Where(a => a.GroupId == groupId)
       from q in Quizzes.Where(a => a.GroupId == groupId)
       from qa in QuizAnswers.Where(a => a.UserId == s.UserId && a.QuizId == q.QuizId).DefaultIfEmpty()
       )
        group tt by new {a.UserId, a.UserFullName}
         into grp
       select new
       {
           UserId = grp.tt.UserId,
           UserFullName = grp.tt.FullName,
           ActivityType = "Quiz",
           ActivityId = grp.tt.QuizId,
           ActivityName = grp.tt.Name,
           DueDate = grp.tt.DueDate,
           Score = grp.tt == null ? null : grp.tt.Score,
           MaxScore = grp.tt != null ? grp.tt.MaxScore ?? 0 : 0,
           IsSent = grp.tt != null && grp.tt.DateSent != null,
       }
       )
       .OrderBy(a => a.DueDate).ThenBy(a => a.ActivityId)
       .AsEnumerable()
