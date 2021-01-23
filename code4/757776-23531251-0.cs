        /// <summary>
        /// If you posted an array of checkboxes to a controller, this will extract the values you expect.
        /// </summary>
        /// <param name="arrayOfCheckboxesFromController">An array of checkboxes passed to the controller</param>        
        /// <remarks>with checkboxes, true values come with a twin false so remove it</remarks>
        private static void GetCheckboxArrayValues(IList<bool> arrayOfCheckboxesFromController)
        {
            for (var i = 0; i < arrayOfCheckboxesFromController.Count(); i++)
            {
                if (!arrayOfCheckboxesFromController[i]) continue;
                // This assumes the caller knows what they are doing and passed in an array of checkboxes posted to a controller
                arrayOfCheckboxesFromController.RemoveAt(i + 1);
            }
        }
