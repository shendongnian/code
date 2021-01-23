    public enum Priority { High, Medium, Low }
    public static class Priorities {
        public static string GetCode(this Priority priority) {
            switch (priority) {
            case Priority.High: return "H";
            case Priority.Medium: return "M";
            case Priority.Low: return "L";
            }
            throw new ArgumentException("priority");
        }
        public static Priority GetPriority(string priorityCode) {
            switch (priorityCode) {
            case "H": return Priority.High;
            case "M": return Priority.Medium;
            case "L": return Priority.Low;
            }
            throw new ArgumentException("priorityCode");
        }
    }
