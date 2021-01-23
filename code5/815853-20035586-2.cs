    public class ElevatorAction
    {
        public string Action { get; set; }
        
        public void Act()
        {
            throw new NotImplementedException();
        }
    }
    // Create two actions (up and down)
    ElevatorAction upAction = new ElevatorAction{ Action = "Up" };
    ElevatorAction downAction = new ElevatorAction{ Action = "Down" };
    // Create the Queue
    Queue<ElevatorAction> elevatorActionQueue = new Queue<ElevatorAction>();
    // Add the actions from your button click events.
    elevatorActionQueue.Enqueue(upAction); // call from button 1 click
    elevatorActionQueue.Enqueue(downAction); // call from button 2 click
    // Loop through the queue to perform the queued actions
    ElevatorAction currentAction = new ElevatorAction();
    while(elevatorActionQueue.Count > 0)
    {
        currentAction = elevatorActionQueue.Dequeue();
        currentAction.Act();
    }
