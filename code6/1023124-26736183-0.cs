    Models.Event.SubDepartment, DTO.SubDepartment>().ForMember(dto => dto.Department, map => map.ResolveUsing<DepartmentResolver>());
    public class DepartmentResolver: ValueResolver<Models.Event.SubDepartment,DTO.SubDepartment>
    {
        Reporsitory _departmentRepository;
        protected override DTO.SubDepartment ResolveCore(Models.Event.SubDepartment source)
        {
            return _departmentRepository.GetById(source.DepartmentId.Value);
        }
    }
