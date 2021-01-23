    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Http.ModelBinding;
    public sealed class ValidateActionParameters_WebApiActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var descriptor = context.ActionDescriptor;
            if (descriptor != null)
            {
                var modelState = context.ModelState;
                foreach (var parameterDescriptor in descriptor.GetParameters())
                {
                    EvaluateValidationAttributes(
                        suppliedValue: context.ActionArguments[parameterDescriptor.ParameterName],
                        modelState: modelState,
                        parameterDescriptor: parameterDescriptor
                    );
                }
            }
   
            base.OnActionExecuting(context);
        }
   
        static private void EvaluateValidationAttributes(HttpParameterDescriptor parameterDescriptor, object suppliedValue, ModelStateDictionary modelState)
        {
            var parameterName = parameterDescriptor.ParameterName;
            
            parameterDescriptor
                .GetCustomAttributes<object>()
                .OfType<ValidationAttribute>()
                .Where(x => !x.IsValid(suppliedValue))
                .ForEach(x => modelState.AddModelError(parameterName, x.FormatErrorMessage(parameterName)));
        }
    }
