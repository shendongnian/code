        private List<DateTime> MergeArray(List<DateTime> slots, int minutes)
        {
            var segments = minutes / InitialSegment;
            var validSegments = new List<DateTime>();
            foreach (var slot in slots.OrderBy(x => x))
            {
                var validSegment = true;
                for (var i = 0; i < segments-1; i++)  
                {
                    var next = slot.AddMinutes(InitialSegment * (i + 1));
                    if (slots.All(x => x != next))
                    {
                        validSegment = false;
                        break;
                    }
                }
                if (validSegment)
                    validSegments.Add(slot);
            }
            return validSegments;
        }
