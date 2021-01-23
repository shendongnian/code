    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Management.Automation;
    
    namespace ExampleNameSpace
    {
        [Cmdlet(VerbsCommon.Get, "Something")]
        [OutputType("PSCustomObject")]
        public class GetSomething : PSCmdlet
        {
            public enum ExampleEnum { A, B, C };
    
            [Parameter(
                HelpMessage = "Enter A, B, or C.",
                Mandatory = true,
                Position = 0,
                ValueFromPipelineByPropertyName = true,
                ValueFromPipeline = true
            )]
            public ExampleEnum ExampleParameter { get; set; }
    
            protected override void ProcessRecord()
            {
                WriteObject(ExampleParameter);
                switch (ExampleParameter)
                {
                    case ExampleEnum.A:
                        WriteObject("Case A");
                        break;
                    case ExampleEnum.B:
                        WriteObject("Case B");
                        break;
                    case ExampleEnum.C:
                        WriteObject("Case C");
                        break;
                    default:
                        break;
                }
            }
        }
    }
