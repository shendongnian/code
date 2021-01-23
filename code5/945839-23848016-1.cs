    public class Character: MonoBehaviour
    {
        private Queue<IEnumerator> commandQueue;
        private IEnumerator CommandQueueCoroutine()
        {
            while (true)
            {
                if (commandQueue.Count > 0)
                    yield return StartCoroutine(commandQueue.Peek());
                else
                    yield return new WaitForFixedUpdate();
            }
        }
        public void Awake()
        {
            commandQueue = new Queue<ICommand>();
            StartCoroutine(CommandQueueCoroutine());
        }
        public void Update()
        {
            if (commandQueue.Count > 0 && commandQueue.Peek().Update() == CommandUpdateResult.Finished)
                commandQueue.Dequeue();
        }
        public void Enqueue(IEnumerator command)
        {
            commandQueue.Enqueue(command);
        }
        IEnumerator RunCommand()
        {
            while (Jenny.Tells("Run"))
            {
                transform.position.x += 1;
                yield return new WaitForFixedUpdate();
            }
        }
        IEnumerator AttackCommand(BadGuy badGuy)
        {
            badGuy.Die();
            yield break;
        }
    }
    public class SomeClassThatUsesCharacter
    {
        private Character character;
        public void SomeMethodThatUsesCharacter()
        {
            character.Enqueue(character.RunCommand());
            character.Enqueue(character.AttackCommand(someBadGuy));
        }
    }
