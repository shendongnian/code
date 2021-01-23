    public class EmployeeClass : PersonBaseClass
    {
        /// <summary>
        /// Hey, this is great method :)
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void InstanceOnPersonChanged(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
