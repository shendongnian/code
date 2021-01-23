    (from tblA in dbo.TableA
    join tblB in dbo.TableB on new { tblA.Student_id, tblA.other_id } equals new { blB.StudentId, tblB.OtherId }
    into tblBJoined
    from tblBResult in tblBJoined.DefaultIfEmpty()
    where tblBResult.Id == null
    select new {
    	TableAData = tblA,
    	TableBData = tblB
    }).ToList();
