    Public Class EmployeeService
        Implements IEmployeeService
        Private ReadOnly _repository As IRepository
        Public Sub New(ByVal repository As IRepository)
            _repository = repository
        End Sub
        Public Function GetAllEmployees() As IEnumerable(Of EmployeeOverviewDto) Implements IEmployeeService.GetAllEmployees
            Dim employees = _repository.ExecuteQuery(EmployeeQueries.GetAllEmployeesForOverview()).List()
            Return employees
        End Function
    End Class
