    public class AddWarriorCommandHandler : ICommandHandler<AddWarriorCommand>
    {
        //ommitted ctor bringing in dependencies (e.g. Repository)
        public void Handle(AddWarriorCommand command)
        {
                var dojo = context.Dojos.Find(command.dojoId);
                dojo.Warriors.Add(command.Warrior);
                context.SaveChanges();
        }
    }
