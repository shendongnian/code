        Outlook.TaskItem _task;
        private void items_ItemAdd(object Item)
        {
            if (Item is Outlook.TaskRequestItem)
            {
                _task = (Item as Outlook.TaskRequestItem).GetAssociatedTask(false);
                _task.PropertyChange += item_PropertyChange;
            }
        }
        void item_PropertyChange(string Name)
        {
            if (Name == "ResponseState" && _task.ResponseState == Outlook.OlTaskResponse.olTaskAccept)
            {
                //some code here
            }
        }
 
