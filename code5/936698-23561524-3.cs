    public class EmployeesController : ApiController
    {
         public HttpResponseMessage POSTEmployee(Employee employee)
         {
              if (ModelState.IsValid)
              {
                 _db.Employees.Add(employee);
                 _db.SaveChanges();
                 HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                 response.Headers.Location = new Uri(Url.Link("Default1", new { Id = employee.Id }));
                 return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
