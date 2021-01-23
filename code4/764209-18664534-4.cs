	[ServiceContract]
	public interface ISurrogateService {
		[OperationContract]
		Tuple<LocalDate, LocalDateTime, ZonedDateTime> GetParams(LocalDate localDate, LocalDateTime localDateTime, ZonedDateTime zonedDateTime);
	}
	public class SurrogateService : ISurrogateService {
		public Tuple<LocalDate, LocalDateTime, ZonedDateTime> GetParams(LocalDate localDate, LocalDateTime localDateTime, ZonedDateTime zonedDateTime) {
			return Tuple.Create(localDate, localDateTime, zonedDateTime);
		}
	}
