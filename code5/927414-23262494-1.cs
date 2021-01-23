    public class Entity
	{
		public string FirstName { get; set; }
		public string FamilyName { get; set; }
		public int CourseId { get; set; }
		public int OccupationId { get; set; }
	}
	public class BaseDto
	{
	}
	public class PersonDto : BaseDto
	{
		public string FirstName { get; set; }
		public string FamilyName { get; set; }
		public static void Map(Entity entity, PersonDto personDto)
		{
			personDto.FirstName = entity.FirstName;
			personDto.FamilyName = entity.FamilyName;
		}
	}
	public class StudentDto : PersonDto
	{
		public int CourseId { get; set; }
		public static StudentDto Map(Entity entity)
		{
			var studentDto = new StudentDto { CourseId = entity.CourseId };
			// ..can call map to PersonDto if you want
			return studentDto;
		}
	}
	public class EmployeeDto : PersonDto
	{
		public int OccupationId { get; set; }
		public static EmployeeDto Map(Entity entity)
		{
			var employeeDto = new EmployeeDto() { OccupationId = entity.OccupationId };
			// ..can call map to PersonDto if you want
			return employeeDto;
		}
	}
	public class Mapper<TDto>
		where TDto : BaseDto
	{
		private TDto _dto;
		private readonly Entity _entity;
		public Mapper(Entity entity)
		{
			_entity = entity;
		}
		public Mapper<TDto> Map(Func<Entity, TDto> map)
		{
			_dto = map(_entity);
			return this;
		}
		public Mapper<TDto> Map<TBaseDto>(Action<Entity, TBaseDto> map)
			where TBaseDto : BaseDto
		{
			map(_entity, _dto as TBaseDto);
			return this;
		}
		public TDto Result
		{
			get { return _dto; }
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var studentEntity = new Entity() { FirstName = "John", FamilyName = "Doe", CourseId = 1 };
			var studentDto = new Mapper<StudentDto>(studentEntity)
				.Map(StudentDto.Map)
				.Map<PersonDto>(PersonDto.Map)
				.Result;
		}
	}
