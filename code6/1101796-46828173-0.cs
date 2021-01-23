    using System;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    public class CharModelBinderProvider : IModelBinderProvider
    {
        /// &lt;inheritdoc /&gt;
        public IModelBinder GetBinder(
            ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(char))
            {
                return new CharModelBinder();
            }
            return null;
        }
    }
    using System;
    using System.ComponentModel;
    using System.Runtime.ExceptionServices;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    /// &lt;inheritdoc /&gt;
    /// &lt;summary&gt;
    ///     An &lt;see cref=&quot;T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder&quot; /&gt; for char.
    /// &lt;/summary&gt;
    /// &lt;remarks&gt;
    ///     Difference here is that we allow for a space as a character which the &lt;see cref=&quot;T:Microsoft.AspNetCore.Mvc.ModelBinding.SimpleTypeModelBinder&quot; /&gt; does not.
    /// &lt;/remarks&gt;
    public class CharModelBinder : IModelBinder
    {
        private readonly TypeConverter _charConverter;
        public CharModelBinder()
        {
            this._charConverter =  new CharConverter();
        }
        /// &lt;inheritdoc /&gt;
        public Task BindModelAsync(
            ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                // no entry
                return Task.CompletedTask;
            }
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
            try
            {
                var value = valueProviderResult.FirstValue;
                var model = this._charConverter.ConvertFrom(null, valueProviderResult.Culture, value);
                this.CheckModel(bindingContext, valueProviderResult, model);
                return Task.CompletedTask;
            }
            catch (Exception exception)
            {
                var isFormatException = exception is FormatException;
                if (!isFormatException &amp;&amp; exception.InnerException != null)
                {
                    // TypeConverter throws System.Exception wrapping the FormatException, so we capture the inner exception.
                    exception = ExceptionDispatchInfo.Capture(exception.InnerException).SourceException;
                }
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, exception, bindingContext.ModelMetadata);
                // Were able to find a converter for the type but conversion failed.
                return Task.CompletedTask;
            }
        }
        protected virtual void CheckModel(
            ModelBindingContext bindingContext,
            ValueProviderResult valueProviderResult,
            object model)
        {
            // When converting newModel a null value may indicate a failed conversion for an otherwise required model (can't set a ValueType to null).
            // This detects if a null model value is acceptable given the current bindingContext. If not, an error is logged.
            if (model == null &amp;&amp; !bindingContext.ModelMetadata.IsReferenceOrNullableType)
            {
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    bindingContext.ModelMetadata.ModelBindingMessageProvider.ValueMustNotBeNullAccessor(valueProviderResult.ToString()));
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Success(model);
            }
        }
    }
