      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (this.SendInAppNotification)
                {
                    if (string.IsNullOrEmpty(this.NotificationTitle) || string.IsNullOrWhiteSpace(this.NotificationTitle))
                    {
                        yield return new ValidationResult(
                            $"Notification Title is required",
                            new[] { nameof(this.NotificationTitle) });
                    }
                }
