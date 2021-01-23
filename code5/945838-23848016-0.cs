    public enum CommandUpdateResult
    {
        Ongoing,
        Finished
    }
    public interface ICommand
    {
       CommandUpdateResult Update();
    }
    public class RunCommand: ICommand
    {
        // Bla-bla-bla
    }
    public class AttackCommand: ICommand
    {
        // Bla-bla-bla
    }
    public class Character: MonoBehaviour
    {
        private Queue<ICommand> commandQueue;
        public void Awake()
        {
            commandQueue = new Queue<ICommand>();
        }
        public void Update()
        {
            if (commandQueue.Count > 0 && commandQueue.Peek().Update() == CommandUpdateResult.Finished)
                commandQueue.Dequeue();
        }
        public void EnqueueCommand(ICommand command)
        {
            commandQueue.Enqueue(command);
        }
    }
    public class SomeClassThatUsesCharacter
    {
        private Character character;
        public void SomeMethodThatUsesCharacter()
        {
            character.EnqueueCommand(new RunCommand(bla-bla-bla));
            character.EnqueueCommand(new AttackCommand(bla-bla-bla));
        }
    }
