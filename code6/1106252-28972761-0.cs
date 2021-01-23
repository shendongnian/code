    <msxsl:script implements-prefix="my" language="csharp">
      <msxsl:assembly name="System.Core" />
      <msxsl:using namespace="System.Linq" />
      <msxsl:using namespace="System.Collections.Generic" />
      <![CDATA[
        public bool myFunc() 
        {
          var d = new Dictionary<string, string>();
          d.Add("Hello", "Goodbye");
          return d.Keys.Contains("Hello");
        }    
      ]]>
    </msxsl:script>
