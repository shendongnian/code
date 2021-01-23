 lang=c#
using System;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// A multicast adapter for <see cref="ObfuscationAttribute"/>. Instructs obfuscation tools to take the specified actions for the target assembly, type, or member.
/// </summary>
[AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.Constructor, AllowMultiple = true, Inherited = false )]
[MulticastAttributeUsage( 
    MulticastTargets.Assembly | MulticastTargets.Class | MulticastTargets.Struct | MulticastTargets.Enum | MulticastTargets.Method | MulticastTargets.Property | MulticastTargets.Field | MulticastTargets.Event | MulticastTargets.Interface | MulticastTargets.Parameter | MulticastTargets.Delegate | MulticastTargets.InstanceConstructor | MulticastTargets.InstanceConstructor,
    AllowMultiple = true,
    PersistMetaData = false)]
public sealed class MulticastObfuscationAttribute : MulticastAttribute, IAspectProvider
{
    bool _stripAfterObfuscation = true;
    bool _exclude = true;
    bool _applyToMembers = true;
    string _feature = "all";
    bool _stripAfterObfuscationIsSpecified;
    bool _excludeIsSpecified;
    bool _applyToMembersIsSpecified;
    bool _featureIsSpecified;
    static readonly ConstructorInfo ObfuscationAttributeCtor = typeof( ObfuscationAttribute ).GetConstructor( Type.EmptyTypes );
    IEnumerable<AspectInstance> IAspectProvider.ProvideAspects( object targetElement )
    {
        var oc = new ObjectConstruction( ObfuscationAttributeCtor );
        if ( _applyToMembersIsSpecified )
            oc.NamedArguments[ nameof( ObfuscationAttribute.ApplyToMembers ) ] = _applyToMembers;
        if ( _excludeIsSpecified )
            oc.NamedArguments[ nameof( ObfuscationAttribute.Exclude ) ] = _exclude;
        if ( _featureIsSpecified )
            oc.NamedArguments[ nameof( ObfuscationAttribute.Feature ) ] = _feature;
        if ( _stripAfterObfuscationIsSpecified )
            oc.NamedArguments[ nameof( ObfuscationAttribute.StripAfterObfuscation ) ] = _stripAfterObfuscation;
        return new[] { new AspectInstance( targetElement, new CustomAttributeIntroductionAspect( oc ) ) };
    }
    /// <summary>
    /// Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the obfuscation tool should remove this attribute after processing.
    /// </summary>
    /// <returns>
    /// <see langword="true" /> if an obfuscation tool should remove the attribute after processing; otherwise, <see langword="false" />. The default is <see langword="true" />.
    /// </returns>
    public bool StripAfterObfuscation
    {
        get => _stripAfterObfuscation;
        set
        {
            _stripAfterObfuscationIsSpecified = true;
            _stripAfterObfuscation = value;
        }
    }
    /// <summary>
    /// Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the obfuscation tool should exclude the type or member from obfuscation.
    /// </summary>
    /// <returns>
    /// <see langword="true" /> if the type or member to which this attribute is applied should be excluded from obfuscation; otherwise, <see langword="false" />. The default is <see langword="true" />.
    /// </returns>
    public bool Exclude
    {
        get => _exclude;
        set
        {
            _excludeIsSpecified = true;
            _exclude = value;
        }
    }
    /// <summary>
    /// Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the attribute of a type is to apply to the members of the type.
    /// </summary>
    /// <returns>
    /// <see langword="true" /> if the attribute is to apply to the members of the type; otherwise, <see langword="false" />. The default is <see langword="true" />.
    /// </returns>
    public bool ApplyToMembers
    {
        get => _applyToMembers;
        set
        {
            _applyToMembersIsSpecified = true;
            _applyToMembers = value;
        }
    }
    /// <summary>
    /// Gets or sets a string value that is recognized by the obfuscation tool, and which specifies processing options.
    /// </summary>
    /// <returns>
    /// A string value that is recognized by the obfuscation tool, and which specifies processing options. The default is "all".
    /// </returns>
    public string Feature
    {
        get => _feature;
        set
        {
            _featureIsSpecified = true;
            _feature = value;
        }
    }
}
