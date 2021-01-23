    public class test
    {
    public string Id{get;set;}
    public string Name{get;set;}
    
    public test(string id, string name)
    
    {
      Id=id;
      Name=name;
    }
    
    than add your take one generc like 
    
    List<Test> lst=new List<test>();
    
    private void Listado2(object sender, ListadoCompletedEventArgs e)
        {
          lst.add(new test(id,name));
           listB.itemsource=lst;
    
        }
