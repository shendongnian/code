    You could queue up your inputs and actions in parallel collections:
                var actions = new Dictionary<int, Func<object[], object>>();
                var inputs = new Dictionary<int, object[]>();
                //when you want to store the action and it's input
                int counter = 0;
                object[] someObjects = new object[] {};
                actions.Add(counter, x => { return x[0]; });
                inputs.Add(counter, someObjects);
                counter++;
                
    
                //and then later when it's time to execute
                foreach (var input in inputs)
                {
                    actions[input.Key].Invoke(input.Value);
                }
