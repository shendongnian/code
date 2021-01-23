        using ActionListAction = System.Action<System.Collections.Generic.LinkedList<Package.Action>, System.Collections.Generic.LinkedListNode<Package.Action> ,Package.Action>;
        
        ...
        private void GoBack()
        {
            Move(new BackwordVisitor());
        }
        private void GoForward()
        {
            Move(new ForwardVisitor());
        }
        private void Move(DirectionVisitor direction)
        {
            var current = _actionLinks.Find(_currentAction);
            if (current == null)
                return;
            var node = direction.Pointer(current);
            if (node != null)
            {
                _currentAction = node.Value;
                return;
            }
            var action = _actions.FirstOrDefault(i => direction.NextSelector(i, _currentAction));
            //There are no further actions
            if (action == null)
                return;
            direction.Add(_actionLinks, current, action);
            _currentAction = action;           
        }
        private abstract class DirectionVisitor
        {
            public Func<LinkedListNode<Action>, LinkedListNode<Action>> Pointer { protected set; get; }
            public Func<Action, Action, bool> NextSelector { protected set; get; }
            public ActionListAction Add { protected set; get; }  
        }
        private class ForwardVisitor : DirectionVisitor
        {
            public Forward()
            {
                Pointer = n => n.Next;
                NextSelector = (action, current) => action.PreviousId == current.Id;
                Add = (list, current, node) => list.AddAfter(current, node);
            }   
        }
        private class BackwordVisitor : DirectionVisitor
        {
            public Backword()
            {
                Pointer = n => n.Previous;
                NextSelector = (action, current) => action.Id == current.PreviousId;
                Add = (list, current, node) => list.AddBefore(current, node);
            }            
        }
