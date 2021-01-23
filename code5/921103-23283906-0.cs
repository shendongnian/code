    select * from 
    (select p1.PubID,p2.Publisher,p2.Title,p.name as authors 
    from Personal_det p,Publication_Tracker p1,Publication_det p2 
    where p.FID=p1.FID and p1.Contribution_Type='A' and p1.PubID=p2.PubID   ) t1 
    inner join 
      (select p.Name as coauthors,p2.PubID,p2.Type,p2.Title,p2.PubDate 
       from Personal_det p,Publication_Tracker p1,Publication_det p2 
       where p.FID=p1.FID and p1.Contribution_Type='C' and p1.PubID=p2.PubID  ) t2 
       on t1.PubID = t2.PubID
