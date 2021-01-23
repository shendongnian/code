    var parm1 = new SqlParameter("parm1", SqlDbType.VarChar, 3);
    var parm2 = new SqlParameter("parm2", SqlDbType.VarChar, 8);
    var parm3 = new SqlParameter("parm3", SqlDbType.VarChar, 2);
    var parm4 = new SqlParameter("parm4", SqlDbType.VarChar, 4);
    
    parm1.Value = p1;
    parm2.Value = p2;
    parm3.Value = p3;
    parm4.Value = p4;
