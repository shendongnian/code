    var batchID = 3;
    var goodStudentIDs = context.Student_batches
        .Where(i => i.BatchID == batchID)
        .Select(i => i.StudentID);
    var badStudentIDs = context.Student_batches
        .Where(i => i.BatchID != batchID)
        .Select(i => i.StudentID);
    var studentIDs = goodStudentIDs.Except(badStudentIDs);
    var students = context.Students.Where(i => studentIDs.Contains(i.ID));
