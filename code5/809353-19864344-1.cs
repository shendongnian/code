        // Here we have the list of actions (things to be done later)
        List<Action> ActionsToPerform;
        // And this will store how far we are through the list
        List<Action>.Enumerator ActionEnumerator;
        // This will allow us to execute a new action after a certain period of time
        Timer ActionTimer;
        
        public ActionsManager()
        {
            ActionsToPerform = new List<Action>();
            // We can describe actions in this lambda format, 
            // () means the action has no parameters of its own
            // then we put => { //some standard c# code goes here }
            // to describe the action
            // CAUTION: See below
            ActionsToPerform.Add(() => { Function1("Some string"); });
            ActionsToPerform.Add(() => { Function2(3); });
            // Here we create a timer so that every thousand miliseconds we trigger the
            // Elapsed event
            ActionTimer = new Timer(1000.0f);
            ActionTimer.Elapsed += new ElapsedEventHandler(ActionTimer_Elapsed);
            // An enumerator starts at the begining of the list and we can work through
            // the list sequentially
            ActionEnumerator = ActionsToPerform.GetEnumerator();
 
            // Move to the start of the list
            ActionEnumerator.MoveNext();
        }
        // This will be triggered when the elpased event happens in out timer
        void ActionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // First we execute the current action by calling it just like a function
            ActionEnumerator.Current();
            // Then we move the enumerator on to the next list
            bool result = ActionEnumerator.MoveNext();
            // if we got false moving to the next, 
            // we have completed all the actions in the list
            if (!result)
            {
                ActionTimer.Stop();
            }
        }
        // Some dummy functions...
        public void Function1(string s)
        {
            Console.WriteLine(s);
        }
        public void Function2(int x)
        {
            Console.WriteLine("Printing hello {0} times", x);
            for (int i = 0; i < x; ++i)
            {
                Console.WriteLine("hello");
            }
        }
