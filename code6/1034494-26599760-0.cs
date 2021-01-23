    public class SetVariable
    {
        Creature ObjectToSet { get; set; }
        Action<Creature, Creature> SetterAction { get; set; }
    
        public SetVariable(Creature objectToSet, Action<Creature, Creature> setterAction)
        {
            this.ObjectToSet = objectToSet;
            this.SetterAction = setterAction;
        }
    
        public Act(Creature parent)
        {
            this.SetterAction(parent, this.ObjectToSet);
            //the setter action would be defined as (when instantiating this object):
            //SetVariable mySet = new SetVariable(null, (target, val) => target.PropertyName = val);
            //it will set the PropertyName property of the target object to val (in this case val=null).
        }
    }
