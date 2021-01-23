    var st=new Stopwatch();
    st.Start();
    db.TblEmployees.Where (t =>t.Age>30).Count ();
    st.Stop();
    Console.WriteLine(st.Elapsed);
    st.Restart();
    db.TblEmployees.Count (t =>t.Age>30);
    st.Stop();
    Console.WriteLine(st.Elapsed);
