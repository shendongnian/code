    <#@ template language="C#" #>
    <#@ output extension=".cs" #>
    <#@ import namespace="NamespaceProofOfConcept" #>
    <#@ assembly name="$(TargetPath)" #>
    
    
    <# Type[] types = new[] {
        typeof(byte), typeof(short), typeof(int),
        typeof(long), typeof(float), typeof(double),
        typeof(bool), typeof(DateTime), typeof(char),
        typeof(string)
        };
    #>
    
    using System;
    namespace NamespaceProofOfConcept {
    public partial class Test {
    <# foreach (var type in types) { 
    #>
        public Test(<#= type.Name #> value) {
            doConstructorStuff(value);
        }
    <#
    } #>
    
    	private void doConstructorStuff(object o){
    		
    	}
    } 
    }
