        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
        public partial class GeneralTranslation {
            
            private string dayField;
            
            private string monthField;
            
            private string yearField;
            
            private string submitField;
            
            private string selectField;
            
            private string[] tradingExpField;
            
            private string[] levelOfInvestmentField;
            
            /// <remarks/>
            public string Day {
                get {
                    return this.dayField;
                }
                set {
                    this.dayField = value;
                }
            }
            
            /// <remarks/>
            public string Month {
                get {
                    return this.monthField;
                }
                set {
                    this.monthField = value;
                }
            }
            
            /// <remarks/>
            public string Year {
                get {
                    return this.yearField;
                }
                set {
                    this.yearField = value;
                }
            }
            
            /// <remarks/>
            public string Submit {
                get {
                    return this.submitField;
                }
                set {
                    this.submitField = value;
                }
            }
            
            /// <remarks/>
            public string Select {
                get {
                    return this.selectField;
                }
                set {
                    this.selectField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Option", IsNullable=false)]
            public string[] TradingExp {
                get {
                    return this.tradingExpField;
                }
                set {
                    this.tradingExpField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Option", IsNullable=false)]
            public string[] LevelOfInvestment {
                get {
                    return this.levelOfInvestmentField;
                }
                set {
                    this.levelOfInvestmentField = value;
                }
            }
        }
    }
