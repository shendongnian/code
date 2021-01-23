    new SamlAttribute() {
    					Name = StringConstants.SAML2_ATTRIBUTE_PREFIX + StringConstants.ATTRIBUTE_INFO_SYSTEMVERSION,
    					Values = new [] {new SamlAttribute.ExtendedAttributeValue(){Type = "xs:string",Value = this.SystemVersion}},
    					NameFormat = StringConstants.ATTRIBUTE_FORMAT
    };
