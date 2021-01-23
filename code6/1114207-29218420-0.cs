    while (msRdr.Read())
    {
        Student st = new Student();
        st.ID = msRdr.GetInt32(0);
        st.Name = msRdr.GetString(1);
        st.Address = msRdr.GetString(3);
        st.Birthdate = msRdr.GetDateTime(2);
        stud.Add(st);
    }
