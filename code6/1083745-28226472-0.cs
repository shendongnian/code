    let isSessionDateLessThanNow = sess.SessionDate < DateTime.Now
    orderby isSessionDateLessThanNow, 
            isSessionDateLessThanNow ? 
               SqlFunctions.DateDiff("s", sess.SessionDate, DateTime.Now) :
               SqlFunctions.DateDiff("s", DateTime.Now, sess.SessionDate)
