    class Factory : Activity
    {
        // ... other code
        
        public IEnumerable<Workstation> GetAllWorkstations()
        {
            return GetWorkstationsRecursive(this);
        }
        
        private IEnumerable<Workstation> WorkstationsIn(Activity parentActivity)
        {
            foreach (var workstation in parentActivity.ChildActivities.OfType<Workstation>)
            {
                // Uses a C# feature called 'iterators' - really powerful!
                yield return workstation;
            }
            foreach (var childActivity in parentActivity.ChildActivities)
            {
                // Using recursion to go down the hierarchy
                foreach (var workstation in WorkstationsIn(childActivity))
                {
                    yield return workstation;
                }
            }
        }
    }
    
