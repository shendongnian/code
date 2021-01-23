    <pre><code>
    Linq2SQLDataClassesDataContext db = new Linq2SQLDataClassesDataContext();
    var query = from p in db.SyncAudits orderby p.SyncTime descending select p;
    Console.WriteLine(query.ToString());
    </code></pre?>
