csharp
    public struct AppointmentId : IEquatable<AppointmentId>
    {
        private readonly string GlobalAppointmentId;
        private readonly LocalDate? OriginalDate;
        public AppointmentId(string globalAppointmentId)
        {
            this.GlobalAppointmentId = globalAppointmentId;
            this.OriginalDate = null;
        }
        public AppointmentId(string globalAppointmentId, LocalDate originalDate)
        {
            this.GlobalAppointmentId = globalAppointmentId;
            this.OriginalDate = originalDate;
        }
        public bool Equals(AppointmentId other)
        {
            return this.GlobalAppointmentId.Equals(other.GlobalAppointmentId, StringComparison.Ordinal) &&
                this.OriginalDate == other.OriginalDate;
        }
        public override bool Equals(object obj) =>
            obj is AppointmentId other && this.Equals(other);
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 62207;
                hash += 3 * this.GlobalAppointmentId.GetHashCode();
                hash += (5 * this.OriginalDate?.GetHashCode() ?? 0);
                return hash;
            }
        }
        public override string ToString()
        {
            if (this.GlobalAppointmentId == null) return "<None>";
            if (this.OriginalDate == null)
            {
                return $"{this.GlobalAppointmentId}";
            }
            return $"{OriginalDate.Value)} / {GlobalAppointmentId}";
        }
        public static bool operator ==(AppointmentId x, AppointmentId y) => x.Equals(y);
        public static bool operator !=(AppointmentId x, AppointmentId y) => !(x == y);
    }
Here I used LocalDate from NodaTime to represent the original date without a time component.
Accessing
--------
The global appointment id can easily be accessed. As mentioned, original date for an occurrence that is not an exception is simply the date part of the appointment start.
Exceptions are more troublesome, when you only have the `AppointmentItem` and not the `Exception` object from `RecurrencePattern`, since the original date is not directly available. But you can get it via `PropertyAccessor`:
csharp
        public static LocalDate GetOriginalDate(this AppointmentItem appointment)
        {
            // The original date is stored in a property called ExceptionReplaceTime but this
            // property is not exposed in the OOM so we need to use PropertyAccessor
            // See: https://docs.microsoft.com/en-us/office/client-developer/outlook/mapi/pidlidexceptionreplacetime-canonical-property
            using (var props = appointment.PropertyAccessor.AsOwnedResource())
            {
                var p = props.Resource.GetProperty("http://schemas.microsoft.com/mapi/id/{00062002-0000-0000-C000-000000000046}/82280040");
                DateTime exceptionReplaceTime = (DateTime)p;
                return props.Resource.UTCToLocalTime(exceptionReplaceTime).ToLocalDate();
            }
        }
