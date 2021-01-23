    public class ModelFirstBase
    {
    public virtual int Id { get; set; }
    public virtual ICollection<ModelFirstSub> Items { get; set; }
    public virtual string Title { get; set; }
    }
    public class ModelFirstSub
    {
    public virtual int Id { get; set; }
    public virtual int FirstId { get; set; }
    public virtual ModelFirstBase First { get; set; }
    public virtual string Title { get; set; }
    }
    public class ModelTranslator
    {
    public ModelFirstSub TranslateModelFirstBase(ModelFirstBase entity)
    {
    //do some error handling and null checks.
    var second = new ModelFirstSub(){
                      FirstId = entity.Id,
                      .....
                 };
    return second;
    }
    }
    public void TransferModels(){ //I haven't thought about disposing stuff, you should.
    var firstContext = new FirstContext();
    var secondContext = new SecondContext();
    foreach (var first in firstContext.ModelFirstBases){
         var second = new ModelTranslator().TranslateModelFirstBase(first);
         secondContext.ModelFirstSubs.Add(second);
    }
    secondContext.SaveChanges();
    }
