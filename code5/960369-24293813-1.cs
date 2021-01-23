    private void button1_Click(object sender, EventArgs e)
        {
            // fires validating events for all controls that are selectable.
            // other constraints are available.
            this.ValidateChildren(ValidationConstraints.Selectable);
        }
        /// <summary>
        /// Handles the validating for a single control or multiple controls.
        /// Depends on the registration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            bool condition = true;
            if (!condition)
            {
                // remaining validation and leave stack will not be performed.
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Handles post validation for a single control or multiple controls.
        /// Depends on the registration.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox1_Validated(object sender, EventArgs e)
        {
            // handle after validation logic here.
            // spray happy faces all over the world.
        }
