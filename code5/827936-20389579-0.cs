    public List<MyTable> GetMyList(int ThisID)`
{
  
return MyEntities.MyTable.Where(c => c.ForeignKey == ThisID).AsEnumerable().ToList();
}
