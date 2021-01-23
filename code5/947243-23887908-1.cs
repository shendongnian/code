    SELECT 
    	tblhomework.ID,
    	tblteacher.TEACHERNAME,
    	tblclass.CLASSNAME,
    	tblhomework.Title,
    	tblhomework.HomeworkDetail,
    	tblhomework.StudentsCode ,
    	tblstudent.StudentsName
    FROM tblstudent 
    JOIN tblhomework ON FIND_IN_SET(tblstudent.StudentsCode, tblhomework.StudentsCode);
    JOIN tblclass ON tblclass.CLASSCODE=tblhomework.ClassCode 
    JOIN tblteacher ON tblteacher.TSHORTNAME=tblhomework.Tshortcode 
    WHERE tblstudent.StudentsCode = '" + studentcode + "'
