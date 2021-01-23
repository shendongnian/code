        public static void AttachActionMessage(this DependencyObject control, string eventName, string methodName, params object[] parameters)
        {
            var action = new ActionMessage { MethodName = methodName };
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    action.Parameters.Add(new Parameter { Value = parameter });
                }
            }
            var trigger = new System.Windows.Interactivity.EventTrigger
            {
                EventName = eventName,
                SourceObject = control
            };
            trigger.Actions.Add(action);
            Interaction.GetTriggers(control).Add(trigger);
        }
