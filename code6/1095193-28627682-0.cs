     Create PROCEDURE yourprocedurename
     AS
     BEGIN
     Select StdBD.First_NameEn As name from TblStudentBioData As StdBD 
     Join TblStudentDetail As StdDet ON StdBD.Student_ID = StdDet.Student_ID
     join TblClassSchedule As ClsSch on StdDet.ClassID = ClsSch.ClassSchID
     join TblClass As Cls on ClsSch.ClassID = Cls.ClassID 
     join TblSemAssigning As SemAs on SemAs.SemAssId = ClsSch.SemAssId
     join TblAcademicYear As Acd on SemAs.AcademicYearId = Acd.AcademicYearId
     where Acd.AcademicYearId = " + userLogin.userId + "FOR XML 
     RAW('Student'),Root('Students'),Elements";
     END
