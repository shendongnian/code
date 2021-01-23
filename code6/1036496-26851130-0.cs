    public class MyCodeGenerator : TemplatedCodeGenerator
    {
        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            ProcessTemplate(inputFileName, CodeGenerationResource.TemplateX);
            ProcessTemplate(inputFileName, CodeGenerationResource.TemplateY);
            
            // since we're using the MultipleOutputHelper class in the t4 templates, which generates the required files on its own, we don't have to return any bytes
            return new byte[0];
        }
        private void ProcessTemplate(string inputFileName, string templateContent)
        {
            var fi = new FileInfo(inputFileName);
            templateContent = templateContent.Replace("Sample.mmd", fi.Name);
            base.GenerateCode(inputFileName, templateContent);
        }
    }
