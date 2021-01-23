    public class QuestionVM: ICloneable
    {
         public Object Clone()
         {
              return new QuestionVM(this.prop1, this.prop2);
         }
    }
    
    ...
    
    return qs
        .Where(w => w.ShowOnParent)
        .Select(obj => (VMQuestion)obj.Clone())
        .ToList();
