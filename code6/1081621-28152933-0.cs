    public enum ExampleEnum
    {
        [ComponentModel.Description("Example One")]
        ExampleOne,
        [ComponentModel.Description("Example Two")]
        ExampleTwo,
        [ComponentModel.Description("Example Three")]
        ExampleThree,
        [ComponentModel.Description("Example Four")]
        ExampleFour,
        ExampleWithNoDescription
    }
    
    @using Mvc4Scratch.Web.Helpers
    @model Mvc4Scratch.Web.ViewModels.EnumExampleViewModel
     
    @{
        ViewBag.Title = "EnumDropDownExample";
    }
     
    <h2>@Model.ExampleTitle</h2>
     
    <div>
        @Html.LabelFor(model => model.ExampleEnum)
        @Html.EnumDropDownListFor(model => model.ExampleEnum)
    </div>
    
    using Mvc4Scratch.Web.Helpers;
     
    namespace Mvc4Scratch.Web.ViewModels
    {
        public class EnumExampleViewModel
        {
            public string ExampleTitle { get; set; }
     
            public ExampleEnum ExampleEnum { get; set; }
        }
    }
    
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
     
    namespace Mvc4Scratch.Web.Helpers
    {
        public static class Extensions
        {
            public static string GetName(this Enum value)
            {
                return Enum.GetName(value.GetType(), value);
            }
     
            public static string GetDescription(this Enum value)
            {
                var fieldInfo = value.GetType().GetField(value.GetName());
                var descriptionAttribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                return descriptionAttribute == null ? value.GetName() : descriptionAttribute.Description;
            }
     
            public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> enumAccessor)
            {
                var propertyInfo = enumAccessor.ToPropertyInfo();
                var enumType = propertyInfo.PropertyType;
                var enumValues = Enum.GetValues(enumType).Cast<Enum>();
                var selectItems = enumValues.Select(s => new SelectListItem
                                                         {
                                                             Text = s.GetDescription(),
                                                             Value = s.ToString()
                                                         });
     
                return htmlHelper.DropDownListFor(enumAccessor, selectItems);
            }
     
            public static PropertyInfo ToPropertyInfo(this LambdaExpression expression)
            {
                var memberExpression = expression.Body as MemberExpression;
                return (memberExpression == null) ? null : memberExpression.Member as PropertyInfo;
            }
        }
    }
